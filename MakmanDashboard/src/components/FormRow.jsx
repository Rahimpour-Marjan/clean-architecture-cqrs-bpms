import styled from 'styled-components';

const StyledFormRow = styled.div`
  display: flex;
  flex-direction: column;
`;

const Error = styled.span`
  color: var(--red-dark);
  font-size: 12px;
  font-weight: 500;
  line-height: 14px;
  padding: 0 1rem;
`;

export const FormRow = ({ error, children }) => {
  return (
    <StyledFormRow>
      {children}
      {error && <Error>{error}</Error>}
    </StyledFormRow>
  );
};
